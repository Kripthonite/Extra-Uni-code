import org.junit.jupiter.api.Test
import problem.TouristPath
import kotlin.time.*

class TouristPathKtTest {
    private val N_TEST = 50
    private val INPUT = "USA-road-d.NY.gr"
    private val OUTPUT = "output.txt"

    private val CMD = "path"
    private val ORG = "125"
    private val DEST = "167"

    @Test
    @ExperimentalTime
    fun Implementation()  {
        println(TouristPathKt(arrayOf(INPUT), ::TouristPath))
    }

    @ExperimentalTime
    fun TouristPathKt(args: Array<String>, m: (args: Array<String>, debugg: String?) -> Unit): Pair<String, String> {
        var sum = 0.0; var idx = 1
        while (idx++ <= N_TEST) { sum += measureTime { m(args, "$CMD $ORG $DEST $OUTPUT") }.inWholeMilliseconds }
        sum /= idx
        return Pair("$CMD $ORG $DEST $OUTPUT","%.2f".format(sum))
    }
}